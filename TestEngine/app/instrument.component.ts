import {Component} from 'angular2/core';
import {Assessments} from './instrument';
import {SectionComponent} from './section.component';
import {Http, Headers} from 'angular2/http';
import {ROUTER_PROVIDERS, RouteConfig} from 'angular2/router'
import {ItemComponent} from './item.component';


@Component({
    selector: 'test-author',
    templateUrl: 'modules/author.html',
    directives: [SectionComponent]
})

export class AppComponent {
  constructor (public http:Http){
    var that = this;

    this.http.get("app/InstrumentExample.js")
    .subscribe(d=>{
      that.instrument = <Assessments.Instrument>d.json();
    });
  }

  public onSectionSelect(section:Assessments.Section) {
    this.selectedSection = section;
  }

  public selectedSection : Assessments.Section;
  public instrument:Assessments.Instrument;
}
