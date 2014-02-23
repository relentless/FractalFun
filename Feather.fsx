#load "FractalFunctions.fsx"
open Fractal

let branchAngle = 0.25
let lengthMultiplier = 1.3/2.0
let widthModifier = -0.5
let startWidth = 3.0
let startLength = 250.0
let numBranches = 5

let asColour x y factor =
    let centredX = abs ((imageCentre - startWidth/2.0) - x)
    int ((centredX+y)/factor%255.0)

let getColour x y =
    (asColour x y 0.5,asColour x y 1.0,asColour x y 1.5)

let rec endpoints x y angle length iteration = seq {
    let segLength = length/float numBranches
    yield endpoint x y (pi*angle) (segLength*float iteration)
    if iteration < numBranches then
        yield! endpoints x y angle length (iteration + 1)
}

let rec branch x y length width colour angle =
    if width > 0.0 then
        let angleDegrees = (pi*angle)
        line x y angleDegrees length width colour

        endpoints x y angle length 0
        |> Seq.iteri ( fun i (nextX, nextY) ->
            let stageLengthMultiplier = (1.0/float numBranches*float i)
            branch nextX nextY (length*lengthMultiplier*stageLengthMultiplier) (width+widthModifier) (getColour x y) (angle+branchAngle)
            branch nextX nextY (length*lengthMultiplier*stageLengthMultiplier) (width+widthModifier) (getColour x y) (angle-branchAngle)
            )

branch (imageCentre - startWidth/2.0) 70.0 startLength startWidth startColour 0.5

form.ShowDialog()
