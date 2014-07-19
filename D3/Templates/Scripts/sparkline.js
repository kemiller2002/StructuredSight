function openGraphUtility(grapher) {
    function getGraph(wrapper) {
        var g = grapher.select(wrapper).append("svg:svg").append("width:100%").append("width:100%");
        var x = g.linear().domain([0, 50]).range([0, 50]);
        var y = g.linear().domain([0, 50]).range([0, 50]);

        var svg = grapher.svg.line().x(function (d, i) {
            return x(d);
        });
    }
}
//# sourceMappingURL=sparkline.js.map
