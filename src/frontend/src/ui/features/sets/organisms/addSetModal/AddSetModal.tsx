import React, { useCallback, useEffect, useState } from 'react';
import { observer } from 'mobx-react';
import { useModalStore } from '@wemogy/reactbase';
import { useAppStore } from '$/domain';
import { Button, Checkbox, Modal, StackLayout, Text, TextInput } from '$/ui/atoms';
import IAddSetModalProps from './IAddSetModalProps';
import IAddSetModalParameters from './IAddSetModalParameters';

const AddSetModal: React.FC<IAddSetModalProps> = ({}) => {
  const { closeModal, getActiveParameters } = useModalStore();
  const { setStore } = useAppStore();
  const activeParameters = getActiveParameters<IAddSetModalParameters>('addSet');

  const [setId, setSetId] = useState('');
  const [forSale, setForSale] = useState(false);
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    setSetId(activeParameters?.setId || '');
  }, [activeParameters?.setId]);

  const handleCancelPress = useCallback(() => {
    closeModal();
  }, [closeModal]);

  const handleAddPress = useCallback(async () => {
    setIsLoading(true);
    await setStore.createSet(setId, forSale);
    setIsLoading(false);
    closeModal();
    activeParameters?.setSearchFieldText('');
  }, [setId, forSale, closeModal, setStore, activeParameters]);

  return (
    <Modal modalKey="addSet" withoutHeader withoutScrollView>
      <StackLayout>
        <StackLayout>
          <Text variation18Grey900Medium marginTop={2.5}>
            Add new set
          </Text>
        </StackLayout>

        <StackLayout marginTop={1.5} marginBottom={3} gap>
          <TextInput
            stretch
            placeholder="Set number"
            onChange={setSetId}
            value={setId}
          />

          <StackLayout orientation="horizontal" vCenter onPress={() => setForSale(!forSale)} gap>
            <Checkbox
              checked={forSale}
              onChange={setForSale}
            />
            <Text variation14Gray900>
              For sale
            </Text>
          </StackLayout>
        </StackLayout>

        <StackLayout orientation="horizontal" vCenter gap={1.5}>
          <Button icon="xMark" secondary14 width100 onPress={handleCancelPress}>
            Cancel
          </Button>

          <Button icon="plus" primary14 width100 onPress={handleAddPress} isLoading={isLoading}>
            Add
          </Button>
        </StackLayout>
      </StackLayout>
    </Modal>
  );
};

export default observer(AddSetModal);
