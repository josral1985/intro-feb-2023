import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css'],
})
export class AboutComponent {
  //the ! operator quiets the "nullable" error
  responseFromServer$!: Observable<StatusResponseModel>;

  /**
   * Read more about Observables:
   * https://angular.io/guide/observables
   *
   */

  constructor(private client: HttpClient) {}

  getStatus() {
    // const result = this.client.get('http://localhost:1337/status');
    // console.log(result);
    // result.subscribe((r) => console.log(r));
    this.responseFromServer$ = this.client.get<StatusResponseModel>(
      'http://localhost:1337/status'
    );
  }
}

type StatusResponseModel = {
  message: string;
  contact: string;
};
