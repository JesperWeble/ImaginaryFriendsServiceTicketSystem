import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component'
import { CreateticketComponent } from './createticket/createticket.component';
import { DetailsComponent } from './details/details.component';


const routeConfig: Routes = [
  {
    path: '',
    component: HomeComponent,
    title: 'Home Page'
  },
  {
    path: 'details/:id',
    component: DetailsComponent,
    title: 'Ticket Details Page'
  },
  {
    path: 'create',
    component: CreateticketComponent,
    title: 'Create Ticket'
  },
];

export default routeConfig;
