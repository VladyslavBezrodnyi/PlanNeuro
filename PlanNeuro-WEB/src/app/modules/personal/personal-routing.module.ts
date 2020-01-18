import {RouterModule, Routes} from '@angular/router';
import {NgModule} from '@angular/core';
import {PersonalBoardComponent} from './components/personal-board/personal-board.component';

const routes: Routes = [
  {
    path: '',
    component: PersonalBoardComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PersonalBoardRoutingModule {
}
