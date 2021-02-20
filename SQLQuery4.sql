


Delete
From Colors
Where ColorId Not In
(
Select MAX(ColorId)
From Colors
Group By ColorName, ColorName
)


