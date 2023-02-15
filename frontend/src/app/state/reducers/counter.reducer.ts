// tell TS about it

import { createReducer, on } from '@ngrx/store';
import { counterEvents } from '../actions/counter.action';

export interface CounterState {
  current: number;
}

// what should this have when the app starts up?

const initialState: CounterState = {
  current: 0,
};

//write a function that is responsive for this branch of the application state
//this func gets a read-only copy of the current state, and any actions that have been dispatched
//and it can return a new state.

export const reducer = createReducer(
  initialState,
  on(counterEvents.countIncremented, (currentState) => ({
    ...currentState,
    current: currentState.current + 1,
  })),
  on(counterEvents.countDecremented, (currentState) => ({
    ...currentState,
    current: currentState.current - 1,
  })),
  on(counterEvents.countReset, () => initialState)
);
