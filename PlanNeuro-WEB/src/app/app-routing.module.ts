import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';


const routes: Routes = [
  {
    path: 'private',
    loadChildren: () => import('./modules/personal/personal.module').then(mod => mod.PersonalModule)
  },
  {
    path: 'public',
    loadChildren: () => import('./modules/public/public.module').then(mod => mod.PublicModule)
  },
  {
    path: 'account',
    loadChildren: () => import('./modules/account/account.module').then(mod => mod.AccountModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
