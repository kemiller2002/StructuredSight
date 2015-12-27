System.register(['angular2/core', './instrument'], function(exports_1) {
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, instrument_1;
    var ItemComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (instrument_1_1) {
                instrument_1 = instrument_1_1;
            }],
        execute: function() {
            ItemComponent = (function () {
                function ItemComponent() {
                }
                Object.defineProperty(ItemComponent.prototype, "item", {
                    get: function () {
                        return this._item;
                    },
                    set: function (item) {
                        this._item = item;
                        console.log("item set.");
                    },
                    enumerable: true,
                    configurable: true
                });
                ItemComponent.prototype.addDistractor = function (item) {
                    console.log('disctractor added.');
                    item.distractors.push(new instrument_1.Assessments.Distractor());
                };
                ItemComponent = __decorate([
                    core_1.Component({
                        selector: 'item-detail',
                        templateUrl: 'modules/item.html',
                        inputs: ['item']
                    }), 
                    __metadata('design:paramtypes', [])
                ], ItemComponent);
                return ItemComponent;
            })();
            exports_1("ItemComponent", ItemComponent);
        }
    }
});
//# sourceMappingURL=item.component.js.map