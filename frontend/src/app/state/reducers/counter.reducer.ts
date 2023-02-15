// tell TS about it

import { createReducer, on } from '@ngrx/store';
import { CountByValues, counterEvents } from '../actions/counter.action';

export interface CounterState {
  current: number;
  by: CountByValues;
}

// what should this have when the app starts up?

const initialState: CounterState = {
  current: 0,
  by: 1,
};

//write a function that is responsive for this branch of the application state
//this func gets a read-only copy of the current state, and any actions that have been dispatched
//and it can return a new state.

export const reducer = createReducer(
  initialState,
  on(counterEvents.countIncremented, (currentState) => ({
    ...currentState,
    current: currentState.current + currentState.by,
  })),
  on(counterEvents.countDecremented, (currentState) => ({
    ...currentState,
    current: currentState.current - currentState.by,
  })),
  on(counterEvents.countReset, (current) => ({ ...current, current: 0 })),
  on(counterEvents.countBySet, (current, amount) => ({
    ...current,
    by: amount.by,
  }))
);
