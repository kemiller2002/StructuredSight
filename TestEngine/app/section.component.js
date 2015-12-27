System.register(['angular2/core', './instrument', './item.component'], function(exports_1) {
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, instrument_1, item_component_1;
    var SectionComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (instrument_1_1) {
                instrument_1 = instrument_1_1;
            },
            function (item_component_1_1) {
                item_component_1 = item_component_1_1;
            }],
        execute: function() {
            SectionComponent = (function () {
                function SectionComponent() {
                }
                Object.defineProperty(SectionComponent.prototype, "section", {
                    get: function () {
                        //console.log('returning section');
                        return this._section;
                    },
                    set: function (section) {
                        this._section = section;
                        console.log('set section');
                    },
                    enumerable: true,
                    configurable: true
                });
                SectionComponent.prototype.addItem = function (section) {
                    console.log('fired item add.');
                    section.items.push(new instrument_1.Assessments.Item());
                };
                SectionComponent.prototype.selectItem = function (item) {
                    console.log('item selected.');
                    this.selectedItem = item;
                };
                SectionComponent.prototype.removeItem = function (section, item) {
                };
                SectionComponent = __decorate([
                    core_1.Component({
                        selector: 'section-detail',
                        templateUrl: 'modules/section.html',
                        inputs: ['section'],
                        directives: [item_component_1.ItemComponent]
                    }), 
                    __metadata('design:paramtypes', [])
                ], SectionComponent);
                return SectionComponent;
            })();
            exports_1("SectionComponent", SectionComponent);
        }
    }
});
//# sourceMappingURL=section.component.js.map