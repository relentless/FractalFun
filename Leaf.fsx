#load "FractalFunctions.fsx"
open Fractal

let branchAngle = 0.25
let lengthMultiplier = 1.0/2.0
let widthModifier = -0.6
let startWidth = 3.0
let startLength = 500.0
let numBranches = 6

let startColour = (00,80,0)
let endColour = (0,180,0)

let numSteps = int (startWidth / -widthModifier)
let step = colourStep startColour endColour numSteps

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
            let stageLengthMultiplier = 1.0 - (0.5/float numBranches*float i)
            let stageWidthMultiplier = 1.0 - (0.1/float numBranches*float i)
            branch nextX nextY (length*lengthMultiplier*stageLengthMultiplier) (width*stageWidthMultiplier+widthModifier) (colour |> next step) (angle+branchAngle)
            branch nextX nextY (length*lengthMultiplier*stageLengthMultiplier) (width*stageWidthMultiplier+widthModifier) (colour |> next step) (angle-branchAngle)
            )

branch (imageCentre - startWidth/2.0) 150.0 startLength startWidth startColour 0.5

form.ShowDialog()
