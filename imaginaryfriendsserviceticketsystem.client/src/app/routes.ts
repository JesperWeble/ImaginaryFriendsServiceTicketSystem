import { Routes } from '@angular/router';
import { StatusComponent } from './status/status.component'


const routeConfig: Routes = [
  {
    path: '',
    component: StatusComponent,
    title: 'Test'
  }];

export default routeConfig;
