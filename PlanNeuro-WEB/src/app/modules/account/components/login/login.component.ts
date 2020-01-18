import {Component, OnDestroy, OnInit} from '@angular/core';
import {AuthorizationService} from '../../../../core/services/authorization.service';
import {Subscription} from 'rxjs';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {EmailRegex} from '../../../../shared/regexes/email-regex';
import {PasswordRegex} from '../../../../shared/regexes/password-regex';
import {LoginModel} from '../../../../shared/models/login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {
  subscription: Subscription;
  submitted: boolean;
  returnUrl: string;
  loginForm: FormGroup;
  errorMessage: string;

  constructor(
    private authenticationService: AuthorizationService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router) {
    if (this.authenticationService.currentUser) {
      this.router.navigate(['/']);
    }
    this.submitted = false;
  }

  createForm(): void {
    this.loginForm = this.fb.group({
      Email: new FormControl(
        '', [Validators.required, Validators.pattern(EmailRegex.Regex)]),
      Password: new FormControl(
        '', [Validators.required, Validators.pattern(PasswordRegex.Regex)])
    });
  }

  ngOnInit() {
    this.createForm();
  }

  onSubmit(): void {
    this.submitted = true;
    const loginViewModel = this.loginForm.value as LoginModel;
    if (this.loginForm.valid) {
      this.login(loginViewModel);
    }
  }

  login(loginModel: LoginModel): void {
    this.subscription = this.authenticationService
      .login(loginModel)
      .subscribe(
        res => this.router.navigate(['../../']),
        errors => this.errorMessage = errors.message);
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
