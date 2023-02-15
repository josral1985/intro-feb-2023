import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { selectCountCountingBy, selectCounterCurrent } from 'src/app/state';
import {
  CountByValues,
  counterEvents,
} from 'src/app/state/actions/counter.action';

@Component({
  selector: 'app-counter-prefs',
  templateUrl: './counter-prefs.component.html',
  styleUrls: ['./counter-prefs.component.css'],
})
export class CounterPrefsComponent {
  constructor(private store: Store) {}

  by$ = this.store.select(selectCountCountingBy);

  setCountBy(by: CountByValues) {
    this.store.dispatch(counterEvents.countBySet({ by }));
  }
}
