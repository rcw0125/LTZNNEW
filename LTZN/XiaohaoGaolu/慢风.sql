DROP Table ����;
Create Table  ����
(
   ʱ��       DATE NOT NULL,
   ��¯       NUMBER(2) NOT NULL,
   ���       NUMBER(20,4),
   ����       VARCHAR2(100),
   ԭ��       VARCHAR2(100),
   CONSTRAINT "��������" PRIMARY KEY(ʱ��,��¯) 
);