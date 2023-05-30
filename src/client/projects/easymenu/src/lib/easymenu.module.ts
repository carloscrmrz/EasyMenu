import {ModuleWithProviders, NgModule} from '@angular/core';
import {CoreConfig} from "./core.config";
import {CORE_CONFIG} from "./core.config.token";


@NgModule({
  declarations: [],
  imports: [],
  exports: []
})
export class EasymenuModule {
  static forRoot(coreConfig: CoreConfig): ModuleWithProviders<EasymenuModule> {
    return {
      ngModule: EasymenuModule,
      providers: [
        {
          provide: CORE_CONFIG,
          useValue: coreConfig
        }
      ]
    };
  }
}
