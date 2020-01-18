import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { FooterComponent } from './shared/components/footer/footer.component';
import {RouterModule} from '@angular/router';
import {NavbarComponent} from './shared/components/navbar/navbar.component';
import {MaterializeModule} from 'angular2-materialize';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {ErrorInterceptor} from './core/interceptors/error.interceptor';
import {ResponseInterceptor} from './core/interceptors/response.interceptor';
import {JwtInterceptor} from './core/interceptors/jwt.interceptor';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {AppRoutingModule} from './app-routing.module';
import {AuthorizationService} from './core/services/authorization.service';
import {BoardService} from './core/services/board.service';
import {CardService} from './core/services/card.service';
import {CardsListService} from './core/services/cards-list.service';
import {RegisterService} from './core/services/register.service';
import { CardComponent } from './shared/card/card.component';
import { CardsListComponent } from './shared/components/cards-list/cards-list.component';
import { BoardComponent } from './shared/components/board/board.component';
import {CardComponent} from './shared/components/card/card.component';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    NavbarComponent,
    CardComponent,
    CardsListComponent,
    BoardComponent,
    CardComponent,
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    RouterModule,
    MaterializeModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  providers: [
    AuthorizationService,
    BoardService,
    CardService,
    CardsListService,
    RegisterService,
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: ResponseInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true}
  ],
  exports: [
    CardsListComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
