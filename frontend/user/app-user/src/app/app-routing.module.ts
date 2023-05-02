import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestComponent } from './components/test/test.component';
import { CareerMapComponent } from './components/career-map/career-map.component';

const routes: Routes = [
  { path: '', redirectTo: '/career-map', pathMatch: 'full' },
  { path: 'career-map', component: CareerMapComponent },
  { path: 'test', component: TestComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
