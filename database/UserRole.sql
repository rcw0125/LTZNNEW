conn lf/lf@liantie;
set echo on;
spool log/UserRole.log;

drop table UserRole;
drop table Roles;

--��ɫ��
create table Roles(
  Name varchar2(255),
  Description varchar2(255),
  CONSTRAINT RolesKey PRIMARY KEY(Name) 
);
insert into Roles(name) values('����Ա');
insert into Roles(name) values('����');
insert into Roles(name) values('ͳ��');
insert into Roles(name) values('��ͨ');
insert into Roles(name) values('1��¯');
insert into Roles(name) values('2��¯');
insert into Roles(name) values('3��¯');
insert into Roles(name) values('4��¯');
insert into Roles(name) values('5��¯');
--�û���ɫ��ϵ��
create table UserRole(
 UserName varchar2(255),
 Role varchar2(255),
 CONSTRAINT UserRoleKey PRIMARY KEY(UserName,Role), 
 CONSTRAINT UserRoleForeignUser FOREIGN KEY(UserName) 
    REFERENCES Users(yonghu), 
 CONSTRAINT UserRoleForeignRole FOREIGN KEY(Role) 
    REFERENCES Roles(Name)
 );
spool off;
exit;