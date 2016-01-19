import {Component} from 'angular2/core';
import {Assessments} from './instrument';
import {SectionComponent} from './section.component';
import {Http, Headers} from 'angular2/http';
import {ROUTER_PROVIDERS, RouteConfig, Router} from 'angular2/router'
import {ItemComponent} from './item.component';
import {InstrumentComponent} from './instrument.component';
import {InstrumentProxy} from './instrumentProxy.service';

@Component({
    selector: 'search',
    templateUrl: 'modules/search.html',
    bindings : [InstrumentProxy]
})

@RouteConfig([
  {path:'/instrument/:id', name:'Instrument', component:InstrumentComponent}
])

export class SearchComponent {
    constructor (private _router:Router, private instrumentProxy:InstrumentProxy) {
    }

    ngOnInit(){
      console.log('fire on Init -> search.')
      this.instrumentProxy.getInstruments().subscribe(x=>this.instruments = x);
    }

    public showDetails(instrument:Assessments.Instrument) {
      this._router.navigate(['Instrument', {id:instrument.id.value}])
    }

    public instruments : Assessments.Instrument[]


}
