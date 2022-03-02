# Province Map

Set your ideal minimum and maximum sizes for land, sea and lake provinces. Then press the **GENERATE** button at the bottom. That's all there is to it.

Feel free to experiment around with the numbers as much as you like!

## Settings

### Distance Function

The distance function determines the boundaries of the provinces. The default is **Euclidean**, and you should leave it that way.

#### Euclidean

Euclidean distance is the length of a line segment between two points in Euclidean space.[[1]](https://wikiless.org/wiki/Euclidean_distance?lang=en) \
In layman's terms, if a pixel is between two points on a two-dimensional plane, the color the pixel is drawn in will be determined by the closest point. In our case, this calculation will be simply done using Pythagorean theorem.

#### Manhattan

Manhattan distance is an alternative distance function, in which the distance between two points is the sum of the absolute differences of their Cartesian coordinates.[[2]](https://wikiless.org/wiki/Taxicab_geometry?lang=en) \
In HOI4 UMT's case, using this distance function will result in more "tetrisy" province boundaries.
