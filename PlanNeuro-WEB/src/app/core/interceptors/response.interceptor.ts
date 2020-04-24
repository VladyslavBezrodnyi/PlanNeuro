import {Injectable, Inject} from '@angular/core';
import {HttpInterceptor, HttpResponse} from '@angular/common/http';
import {HttpRequest} from '@angular/common/http';
import {HttpHandler} from '@angular/common/http';
import {HttpEvent} from '@angular/common/http';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import {ApiResponse} from 'src/app/shared/models/api-response.model';
// import {SnackBarComponent} from '../../shared/components/snack-bar/snack-bar.component';
import * as M from 'angular2-materialize';

@Injectable()
export class ResponseInterceptor implements HttpInterceptor {
  constructor(/*private snackBar: SnackBarComponent*/) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      map((event: HttpEvent<any>) => {
        if (event instanceof HttpResponse) {
          const responseBody = event.body as ApiResponse;
          if (responseBody.StatusCode !== 200) {
            if (responseBody.ErrorCode === 1) {
              throw new Error(responseBody.Details);
            } else {
              console.log(responseBody.Details)
              M.toast([responseBody.Details, 3000, 'rounded']);
              /// this.snackBar.displaySnackBar(responseBody.Details);
            }
          }
          return event.clone({body: responseBody.Data});
        }
      })
    );
  }
}
