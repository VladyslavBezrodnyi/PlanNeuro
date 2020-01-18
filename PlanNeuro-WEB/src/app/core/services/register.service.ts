import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../../environments/environment.prod';
import {Injectable} from '@angular/core';
import {RegistrationModel} from '../../shared/models/registration.model';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  private CONTROLLER_URL: string = environment.API_URL + '/account';

  constructor(private http: HttpClient) {
  }

  registerAsync(registerModel: RegistrationModel): Observable<any> {
    return this.http.post(this.CONTROLLER_URL + '/register', registerModel);
  }
}
