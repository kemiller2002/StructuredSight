import {Component} from 'angular2/core';
import {Assessments} from './instrument';

@Component({
    selector: 'test-author',
    templateUrl: 'modules/author.html'
})

export class AppComponent {
  constructor (){
    this.instrument = new Assessments.Instrument();
    this.instrument.sections.push(new Assessments.Section())
    this.instrument.sections[0].description.text = "NEW NEW NEW"
  }

  public onSectionSelect(section:Assessments.Section) {
    this.selectedSection = section;
  }

  public addItem(section:Assessments.Section){
    section.items.push(new Assessments.Item());
  }

  public removeItem(section:Assessments.Section, item:Assessments.Item){
    
  }

  public selectedSection : Assessments.Section;
  public instrument:Assessments.Instrument;
}
