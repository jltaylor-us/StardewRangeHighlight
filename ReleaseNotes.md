
# Release Notes

## Version 1.1.1

* Change the default key bindings so that they do not conflict
  with the default movement keys.  (Keep in mind that if the
  `config.json` has already been generated with the old defaults
  then they won't be overwritten with the new defaults.)

## Version 1.1.0

### User-visible Changes

* Bomb ranges are now highlighted when a bomb is equipped.
  (Ranges of bombs already on the ground are not shown.)

### API Changes

* Two new functions have been added to the API:
  * `GetCartesianCircleWithTruncate` truncates a tile's distance from
    the origin to an integer before comparing it against the radius.
    This is the same as the existing `GetCartesianCircle`.
  * `GetCartesianCircleWithRound` rounds a tile's distance from
    the origin to the nearest integer before comparing it against the radius.
    (This is the shape of a bomb's blast.)
* The `GetCartesianCircle` function is now deprecated.

-----

## Version 1.0.0

Initial release
