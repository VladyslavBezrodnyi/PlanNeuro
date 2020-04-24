import {AfterViewInit, Component, OnDestroy, OnInit} from '@angular/core';
import {AuthorizationService} from '../../../core/services/authorization.service';
import {Subscription} from 'rxjs';
import {FormControl} from '@angular/forms';
import {Router} from '@angular/router';

declare var $: any;

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit, AfterViewInit, OnDestroy {
  subscription: Subscription;
  querryFormControl: FormControl;
  isLogged = false;
  role = '';

  constructor(private autorizationService: AuthorizationService) {
    autorizationService.isLoggedIn.subscribe(x => this.isLogged = x);
    this.getRole();
    console.log(this.role);
  }

  ngOnInit() {
    this.querryFormControl = new FormControl('');
    this.getRole();
    console.log(this.role);
  }

  ngAfterViewInit() {
    setTimeout(() => {
      $(document).ready(() => {
        $('.button-collapse').sideNav();
      });
    }, 1000);
  }

  logOut() {
    this.autorizationService.logout();
    this.role = '';
    console.log(this.role);
  }

  getRole(): string {
    this.subscription = this.autorizationService
      .UserRole
      .subscribe(data => this.role = data);
    return this.role;
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
