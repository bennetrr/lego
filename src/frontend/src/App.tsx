import React, { useRef } from 'react';
import { observer } from 'mobx-react';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import { Toast } from 'primereact/toast';
import { ToastProvider } from './utils';
import appRoutes from './App.routes.tsx';
import { ConfirmDialog } from 'primereact/confirmdialog';
import { ConfirmPopup } from 'primereact/confirmpopup';

const appRouter = createBrowserRouter(appRoutes);

const App: React.FC = observer(() => {
  const toast = useRef<Toast>(null);

  return (
    <>
      <ToastProvider value={toast}>
        <RouterProvider router={appRouter} />
      </ToastProvider>

      <Toast ref={toast} />
      <ConfirmDialog />
      <ConfirmPopup />
    </>
  );
});

export default App;
