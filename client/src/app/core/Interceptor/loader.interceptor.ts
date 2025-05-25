import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { LoadingService } from '../Services/loading.service';
import { finalize } from 'rxjs/operators';

export const loaderInterceptor: HttpInterceptorFn = (req, next) => {
  const loadingService = inject(LoadingService);

  console.log('HTTP request intercepted:', req.url);

  loadingService.RequestCount++;
  loadingService.showLoading();

  return next(req).pipe(
    finalize(() => {
      loadingService.RequestCount--;
      if (loadingService.RequestCount <= 0) {
        loadingService.RequestCount = 0;
        loadingService.hideLoading();
      }
    })
  );
};
