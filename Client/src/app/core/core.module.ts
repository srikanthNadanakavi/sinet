import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';
import { TestErrorComponent } from './test-error/test-error.component';
import { ToastrModule } from 'ngx-toastr';
import { NotfoundErrorComponent } from './notfound-error/notfound-error.component';
import { ServerErrorComponent } from './server-error/server-error.component';

@NgModule({
  declarations: [
    NavBarComponent,
    TestErrorComponent,
    NotfoundErrorComponent,
    ServerErrorComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
    }),
  ],
  exports: [NavBarComponent],
})
export class CoreModule {}
