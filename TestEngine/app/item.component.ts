import {Component} from 'angular2/core'
import {Assessments} from './instrument'


@Component({
  selector : 'item-detail',
  templateUrl : 'modules/item.html',
  inputs : ['item']
})

export class ItemComponent {

  private _item : Assessments.Item;
  public set item (item:Assessments.Item) {
    this._item = item;
    console.log("item set.");
  }

  public get item () : Assessments.Item {
    return this._item;
  }

  public addDistractor(item:Assessments.Item){
    console.log('disctractor added.');
    item.distractors.push(new Assessments.Distractor());
  }

}
