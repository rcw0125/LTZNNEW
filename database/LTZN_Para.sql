conn lf/lf@liantie;
set echo on;
spool log/LTZN_Para.log;
drop table LTZN_Para;
create table LTZN_Para(
 Name varchar2(1000),
 Val number(18,8),
 StrVal varchar2(1000),
 Constraint LTZN_Para_Primary_Key Primary Key(Name)
 );
insert into LTZN_Para(Name,Val) values('Si���',0.7);
insert into LTZN_Para(Name,Val) values('Si�δ�',0.5);
insert into LTZN_Para(Name,Val) values('Si��С',0.3);
insert into LTZN_Para(Name,Val) values('Si��С',0.2);
insert into LTZN_Para(Name,Val) values('S��ֵ����',0.030021);
insert into LTZN_Para(Name,Val) values('S��ֵ��ֵ',0.02024);
insert into LTZN_Para(Name,Val) values('S��ֵ����',0.010027);
insert into LTZN_Para(Name,Val) values('S��������',0.01225);
insert into LTZN_Para(Name,Val) values('S�����ֵ',0.00375);
insert into LTZN_Para(Name,Val) values('S��������',0);
insert into LTZN_Para(Name,Val) values('R���',1.25);
insert into LTZN_Para(Name,Val) values('R�δ�',1.20);
insert into LTZN_Para(Name,Val) values('R��С',1.07);
insert into LTZN_Para(Name,Val) values('R��С',1);
insert into LTZN_Para(Name,Val) values('Si��ʾ���ֵ',1);
insert into LTZN_Para(Name,Val) values('Si��ʾ��Сֵ',0);
insert into LTZN_Para(Name,Val) values('S��ʾ���ֵ',1);
insert into LTZN_Para(Name,Val) values('S��ʾ��Сֵ',0);
insert into LTZN_Para(Name,Val) values('R��ʾ���ֵ',1);
insert into LTZN_Para(Name,Val) values('R��ʾ��Сֵ',0);
spool off;
exit;