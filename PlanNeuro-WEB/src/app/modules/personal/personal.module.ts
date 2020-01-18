import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonalBoardComponent } from './components/personal-board/personal-board.component';
import {PersonalBoardRoutingModule} from './personal-routing.module';
import {AppModule} from '../../app.module';



@NgModule({
  declarations: [PersonalBoardComponent],
  imports: [
    CommonModule,
    PersonalBoardRoutingModule,
    AppModule
  ]
})
export class PersonalModule { }
