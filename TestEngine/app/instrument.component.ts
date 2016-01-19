import {Component} from 'angular2/core';
import {Assessments} from './instrument';
import {SectionComponent} from './section.component';
import {Http, Headers} from 'angular2/http';
import {ItemComponent} from './item.component';
import {ROUTER_PROVIDERS, RouteConfig, Router, RouteParams} from 'angular2/router'

@Component({
    selector: 'test-author',
    templateUrl: 'modules/author.html',
    directives: [SectionComponent]
})

export class InstrumentComponent {
  constructor (private _router:Router, private _parms:RouteParams) {
    this._currentId = _parms.get('id');
  }

  private _currentId:string;

  public onSectionSelect(section:Assessments.Section) {
    this.selectedSection = section;
  }

  public selectedSection : Assessments.Section;
  public instrument:Assessments.Instrument;
}
