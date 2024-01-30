import React, { useEffect } from 'react';
import { observer, Provider as MobxProvider } from 'mobx-react';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import { ReactBaseProvider, Toaster } from '@wemogy/reactbase';
import { DefaultTheme, themeDeclaration } from '$/ui';
import { AppStore, AuthenticationService, setupAxiosInstance } from '$/domain';
import appRoutes from './App.routes.tsx';

setupAxiosInstance(window.env.apiBaseUrl);
AuthenticationService.initialize();

const appRouter = createBrowserRouter(appRoutes);
const appStore = AppStore.create();

AuthenticationService.addTokenChangeHandler(token => appStore.authenticationStore.setIsAuthenticated(!!token));
appStore.authenticationStore.setIsAuthenticated(AuthenticationService.isAuthenticated);

const App: React.FC = () => {
  useEffect(() => {
    if (!AuthenticationService.isAuthenticated) {
      return;
    }
    
    appStore.setStore.querySets();
  }, [appStore.authenticationStore.isAuthenticated]);

  return (
      <MobxProvider
          appStore={appStore}
      >
        <ReactBaseProvider
            theme={DefaultTheme}
            themeDependencies={{
              useThemeModeHook: () => 'default',
              themeDeclaration
            }}
        >
          <RouterProvider
              router={appRouter}
          />
          
          <Toaster
              closeButton
              richColors
              position="top-right"
              style={{ top: 16, right: 16 }}
          />
        </ReactBaseProvider>
      </MobxProvider>
  );
}

export default observer(App);
