import { Component } from '@angular/core';
import { catchError, Observable, of, tap } from 'rxjs';
import { StatusResponseModel } from 'src/app/models/status.models';
import { StatusDataService } from 'src/app/services/status-data.service';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css'],
})
export class AboutComponent {
  //the ! operator quiets the "nullable" error
  responseFromServer$!: Observable<StatusResponseModel>;
  hasError = false;

  /**
   * Read more about Observables:
   * https://angular.io/guide/observables
   *
   */

  constructor(private service: StatusDataService) {}

  getStatus() {
    // const result = this.client.get('http://localhost:1337/status');
    // console.log(result);
    // result.subscribe((r) => console.log(r));
    this.responseFromServer$ = this.service.getStatus().pipe(
      tap(() => (this.hasError = false)),
      catchError(() => {
        this.hasError = true;
        return of({ message: 'unavailable', contact: 'unavailable' });
      })
    );
  }
}
