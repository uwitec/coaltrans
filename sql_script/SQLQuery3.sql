select * from dbo.Supply

insert into supply(Subject,CoalType,Category,UserID,CreatedOn,ValidDate,Region,
Description,WholesaleDes,ShipDes,Volatility,GrainSize,AshContent,SurfurContent,
WaterContent,CalorificPower)
values('供应石化专用/ 无烟煤 滤料无烟煤',1,1,1,getdate(),'2009-12-31',1,
'精制无烟煤滤料采用山西优质白煤为原料，经精选碎，粉，筛等工艺加工而成是普遍采用双层，三层快速过滤材料。实用于一般酸性，中性碱性的净化处理，具有良好的比表面积，各项指标均达到建设部（CJ/T44-1999）标准。',
'与卖家联系','与卖家联系',1,1,1,1,1,6000)
