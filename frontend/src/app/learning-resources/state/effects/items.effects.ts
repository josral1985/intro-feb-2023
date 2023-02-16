import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { concatMap, map, switchMap } from 'rxjs';
import { itemsDocuments, itemsEvents } from '../actions/items.actions';
import { learningResourcesEvents } from '../actions/learning-resources.actions';
import { ItemEntity } from '../reducers/items.reducers';

@Injectable()
export class ItemsEffects {
  addItem$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(itemsEvents.created),
      concatMap((a) =>
        this.client
          .post<ItemEntity>('http://localhost:1337/resources', a.payload)
          .pipe(map((payload) => itemsDocuments.item({ payload })))
      )
    );
  });
  loadItemsOnFeatureEntered$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(learningResourcesEvents.entered),
      switchMap(() =>
        this.client
          .get<{ items: ItemEntity[] }>('http://localhost:1337/resources')
          .pipe(
            map((response) => response.items),
            map((payload) => itemsDocuments.items({ payload }))
          )
      )
    );
  });
  constructor(private actions$: Actions, private client: HttpClient) {}
}
