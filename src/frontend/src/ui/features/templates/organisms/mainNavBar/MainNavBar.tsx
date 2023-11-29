import React from 'react';
import IMainNavBarProps from './IMainNavBarProps';
import { Link } from 'react-router-dom';
import { StackLayout, Text, Icon } from '$/ui';

const MainNavBar: React.FC<IMainNavBarProps> = ({}) => {
  return (
      <StackLayout padding={2} vCenter orientation="horizontal" backgroundColor="greyDark">
        <Link to="/">
          <Text variation20WhiteMedium>LegoApp</Text>
        </Link>
        
        <StackLayout stretch/>
        
        <Link to={'/settings'}>
          <Icon icon="user" variation3GreyLight/>
        </Link>
      </StackLayout>
  );
}

export default MainNavBar;
