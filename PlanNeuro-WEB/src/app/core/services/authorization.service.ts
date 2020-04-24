import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {map} from 'rxjs/operators';
import {UserModel} from 'src/app/shared/models/user.model';
import {environment} from 'src/environments/environment.prod';
import * as jwt_decode from 'jwt-decode';
import {BehaviorSubject, Observable} from 'rxjs';
import {TokenResponse} from 'src/app/shared/models/token-response.model';
import {LoginModel} from 'src/app/shared/models/login.model';
import {Router} from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {
  public currentUser: UserModel;
  private loggedIn = new BehaviorSubject<boolean>(false);
  private Role = new BehaviorSubject<string>(null);

  constructor(private http: HttpClient) {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    this.loggedIn.next(this.currentUser != null);
    if (this.currentUser) {
      this.Role.next(this.currentUser.Role);
    } else {
      this.Role.next(null);
    }
  }

  get isLoggedIn(): Observable<boolean> {
    return this.loggedIn.asObservable();
  }

  get UserRole(): Observable<string> {
    return this.Role.asObservable();
  }

  login(userLoginViewModel: LoginModel): Observable<TokenResponse> {
    return this.http.post<TokenResponse>(environment.API_URL + `/account/login`, userLoginViewModel)
      .pipe(map(tokenResponse => {
        const token = tokenResponse.accessToken;
        this.currentUser = this.setUserInfo(token, userLoginViewModel.Email);
        localStorage.setItem('currentUser', JSON.stringify(this.currentUser));
        this.loggedIn.next(true);
        this.Role.next(this.currentUser.Role);
        return tokenResponse;
      }));
  }

  logout(): void {
    localStorage.removeItem('currentUser');
    this.currentUser = null;
    this.loggedIn.next(false);
    this.Role.next(null);
  }

  setUserInfo(token: string, email: string): UserModel {
    const decodedToken = jwt_decode(token);
    return ({
      Id: decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'],
      Email: email,
      Token: token,
      Role: decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']
    } as UserModel);
  }
}
