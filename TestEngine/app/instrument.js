System.register([], function(exports_1) {
    var Assessments;
    return {
        setters:[],
        execute: function() {
            (function (Assessments) {
                var Timer = (function () {
                    function Timer() {
                    }
                    return Timer;
                })();
                Assessments.Timer = Timer;
                var Text = (function () {
                    function Text() {
                    }
                    return Text;
                })();
                Assessments.Text = Text;
                var Distractor = (function () {
                    function Distractor() {
                        this.display = new Text();
                    }
                    return Distractor;
                })();
                Assessments.Distractor = Distractor;
                var Item = (function () {
                    function Item() {
                        this.introDelayInSeconds = new Timer();
                        this.question = new Text();
                        this.distractors = new Array();
                    }
                    return Item;
                })();
                Assessments.Item = Item;
                var Section = (function () {
                    function Section() {
                        this.description = new Text();
                        this.title = new Text();
                        this.items = new Array();
                    }
                    return Section;
                })();
                Assessments.Section = Section;
                var Instrument = (function () {
                    function Instrument() {
                        this.title = new Text();
                        this.sections = new Array();
                        this.description = new Text();
                    }
                    return Instrument;
                })();
                Assessments.Instrument = Instrument;
            })(Assessments = Assessments || (Assessments = {}));
            exports_1("Assessments", Assessments);
        }
    }
});
//# sourceMappingURL=instrument.js.map