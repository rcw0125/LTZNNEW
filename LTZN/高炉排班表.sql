declare
t Date;
begin
t:=to_date('2006-07-06','YYYY-MM-DD');
while t<to_date('2008-07-01','YYYY-MM-DD') loop
insert into ��¯�Ű�� values(t,'ҹ��','����');
insert into ��¯�Ű�� values(t,'�а�','����');
insert into ��¯�Ű�� values(t,'�װ�','����');
insert into ��¯�Ű�� values(t+1,'ҹ��','�װ�');
insert into ��¯�Ű�� values(t+1,'�а�','�Ұ�');
insert into ��¯�Ű�� values(t+1,'�װ�','�Ұ�');
insert into ��¯�Ű�� values(t+2,'ҹ��','����');
insert into ��¯�Ű�� values(t+2,'�а�','����');
insert into ��¯�Ű�� values(t+2,'�װ�','�Ұ�');
insert into ��¯�Ű�� values(t+3,'ҹ��','�Ұ�');
insert into ��¯�Ű�� values(t+3,'�װ�','�װ�');
insert into ��¯�Ű�� values(t+3,'�װ�','�Ұ�');
t:=t+4;
end loop;
commit;
end;