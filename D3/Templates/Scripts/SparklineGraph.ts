interface IHtml {
    attr(key: string, value: string): IHtml;
    attr(key: string, transform: (d: number, i: number) => string): IHtml;
    attr(key: string, value: number): IHtml;
    append(node: string): IHtml;
}

interface IGraphUtility {
    select(node: string): IHtml;
    selectAll(node: string): IHtml[]
}

interface IGraphObject {
    graph(node: string): void;
    
}

interface IBounds {
    update(lower: number, upper: number);
}

interface IDimension {
    Range: IBounds;
}

function openSparkGraphUtility(grapher: IGraphingUtility): (string) => void {

    return (wrapper: string) => {

        var g = grapher.select("#" + wrapper).append("svg:svg").attr("width", "100%").attr("height", "100%");
        var x = grapher.scale.linear().domain([0, 50]).range([0, 100]);
        var y = grapher.scale.linear().domain([0, 50]).range([0, 100]);

        var svg = d3.svg.line().x((d, i) => { return x(i); }).y((d, i) => { return y(d); });

        return (data: number[]) => { g.append("svg:path").attr("d", svg(data)); };
    };
}