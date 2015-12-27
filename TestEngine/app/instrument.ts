export module Assessments {

export interface DisplayText {
  text : string ;
}

export interface Identifier {
  value : string;
}

export class StringIdentifier implements Identifier {
   constructor(id:string){
     this.value = id;
   }
    public value : string;
}

export class NumberId implements Identifier {
  private _id : number

  public get value () : string {
    return this._id.toString();
  }

  public set value (id:string) {
    this._id = parseInt(id)
  }

}


export class Timer {
  seconds:number;
}

export class Text implements DisplayText {
  public text : string;
}

 export class Distractor {
    constructor() {
      this.display = new Text();
      this.weight = 0;
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
      this.id = new StringIdentifier("");
    }

    id : Identifier;
    title:DisplayText;
    description:DisplayText;
    sections:Section[];
  }

}
