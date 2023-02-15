import {
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
} from '@ngrx/store';
// import { CounterState, reducer } from './reducers/counter.reducer';
import * as fromCounter from './reducers/counter.reducer';

// the "application state"
//index.ts is the default. won't have to add the file to the import
export interface AppState {
  counter: fromCounter.CounterState;
}

export const reducers: ActionReducerMap<AppState> = {
  counter: fromCounter.reducer,
};

// 1. create a "feature selector"
const selectCounterFeature =
  createFeatureSelector<fromCounter.CounterState>('counter');
// 2. create a selector per branch of the state

// 3. any helpers (optional)

//what does the component need
// we need a selector that returns the current of the counter

export const selectCounterCurrent = createSelector(
  selectCounterFeature,
  (f) => f.current
);
