export module Assessments {

export interface DisplayText {
  text : string ;
}

export class Timer {
  seconds:number;
}

export class Text implements DisplayText {
  public text : string;
}

 export class Distractor{
    constructor(){
      this.display = new Text();
    }
    display:DisplayText;
    weight:number;
  }

  export class Item {
    constructor(){
      this.introDelayInSeconds = new Timer();
      this.question = new Text();
      this.distractors = new Array<Distractor> ();
    }

    introDelayInSeconds:Timer;
    question:DisplayText;
    distractors : Distractor[];
  }

  export class Section {
    constructor() {
      this.description = new Text();
      this.title = new Text();
      this.items = new Array<Item>();
    }
    items:Item[];
    randomize:boolean;
    itemBanking:boolean;
    numberPerpage:number;
    description:DisplayText;
    title:DisplayText;
  }

  export class Instrument {
    constructor () {
      this.title = new Text();
      this.sections = new Array<Section>();
      this.description = new Text();
    }
    title:DisplayText;
    description:DisplayText;
    sections:Section[];
  }

}
