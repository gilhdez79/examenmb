import { Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { ProyectosListComponent } from './components/proyectoss/proyectos-list/proyectos-list.component';
import { TaskListComponent } from './components/tareas/task-list/task-list.component';

export const routes: Routes = [
     { path: 'login', component: LoginComponent },
  { path: 'projects', component: ProyectosListComponent },
  { path: 'tasks', component: TaskListComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
];
