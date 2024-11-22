import { Routes } from '@angular/router';
import { CounterComponent } from './counter/counter.component';
import { AppComponent } from './app.component';

export const routes: Routes = [
  {
    path: 'counter',
    component: CounterComponent,
  },
  {
    path: '**',
    component: AppComponent,
  },
];
