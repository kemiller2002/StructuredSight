import {Component} from 'angular2/core'
import {Assessments} from './instrument';
import {ItemComponent} from './item.component';
@Component({
    selector: 'section-detail',
    templateUrl: 'modules/section.html',
    inputs:['section'],
    directives: [ItemComponent]
  }
)

export class SectionComponent {
  private _section:Assessments.Section
  public selectedItem:Assessments.Item;
  public newQuestionText : string;
  
  public set section (section:Assessments.Section){
    this._section = section;
    console.log('set section');
  }

  public get section () : Assessments.Section {
    //console.log('returning section');
    return this._section;
  }


  public addItem(section:Assessments.Section){
    console.log('fired item add.')
    section.items.push(new Assessments.Item());
  }

  public selectItem(item:Assessments.Item){
    console.log('item selected.')
    this.selectedItem = item;
  }

  public removeItem(section:Assessments.Section, item:Assessments.Item){

  }
}
