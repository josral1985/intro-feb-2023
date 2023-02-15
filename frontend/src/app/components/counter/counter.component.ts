import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { selectCounterCurrent } from 'src/app/state';
import { counterEvents } from 'src/app/state/actions/counter.action';

@Component({
  selector: 'app-counter',
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.component.css'],
})
export class CounterComponent {
  //current = 0;

  //naming convention of appending an $ to observable
  current$ = this.store.select(selectCounterCurrent);

  /**
   *
   */
  constructor(private store: Store) {}

  increment() {
    //this.current += 1;
    this.store.dispatch(counterEvents.countIncremented());
  }

  decrement() {
    //this.current -= 1;
    this.store.dispatch(counterEvents.countDecremented());
  }

  reset() {
    this.store.dispatch(counterEvents.countReset());
  }
}
