import {Component, EventEmitter, OnDestroy, OnInit, Output} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {AuthorizationService} from '../../../../core/services/authorization.service';
import {NameRegex} from '../../../../shared/regexes/name-regex';
import {EmailRegex} from '../../../../shared/regexes/email-regex';
import {PasswordRegex} from '../../../../shared/regexes/password-regex';
import {Router} from '@angular/router';
import {RegisterService} from '../../../../core/services/register.service';
import {Subscription} from 'rxjs';
import {LoginModel} from '../../../../shared/models/login.model';
import {RegistrationModel} from '../../../../shared/models/registration.model';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit, OnDestroy {
  subscription: Subscription;
  registerForm: FormGroup;
  errorMessage: string = null;

  constructor(
    private fb: FormBuilder,
    private authorizationService: AuthorizationService,
    private registerService: RegisterService,
    private router: Router
  ) {
  }

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    this.registerForm = this.fb.group({
        Email: new FormControl(
          '', [Validators.required, Validators.pattern(EmailRegex.Regex)]),
        Password: new FormControl(
          '', [Validators.required, Validators.minLength(6), Validators.pattern(PasswordRegex.Regex)]),
        ConfirmPassword: new FormControl(
          '', [Validators.required]),
        Name: new FormControl(
          '', [Validators.required, Validators.maxLength(50), Validators.pattern(NameRegex.Regex)])
      },
      {
        validator: FormControlMustMatchValidate('Password', 'ConfirmPassword')
      });
  }

  login(loginModel: LoginModel) {
    this.authorizationService
      .login(loginModel)
      .subscribe(x => {
        this.router.navigate(['/']);
      });
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  onSubmit() {
    console.log('(onSubmit) => INVALID');
    console.log(this.registerForm.status);
    if (this.registerForm.status === 'VALID') {
      console.log('(onSubmit) => VALID');
      this.subscription = this.registerService
        .registerAsync(this.registerForm.value as RegistrationModel)
        .subscribe(res => {
            const loginModel = this.registerForm.value as LoginModel;
            console.log('loginModel => ', loginModel);
            this.login(loginModel);
          },
          errors => {
            this.errorMessage = errors.message;
          });
    }
  }
}

export function FormControlMustMatchValidate(controlName: string, matchingControlName: string) {
  return (formGroup: FormGroup) => {
    const control = formGroup.controls[controlName];
    const matchingControl = formGroup.controls[matchingControlName];

    if (matchingControl.errors && !matchingControl.errors.mustMatch) {
      return;
    }

    if (control.value !== matchingControl.value) {
      matchingControl.setErrors({mustMatch: true});
    } else {
      matchingControl.setErrors(null);
    }
  };
}
