DROP Table ��ԭ�ϳɷ�;
Create Table ��ԭ�ϳɷ�
(
    P01����       DATE NOT NULL,
    P02����       VARCHAR2(20) NOT NULL,
    P03TFE        NUMBER(20,4),
    P04SIO2       NUMBER(20,4),
    P05CAO        NUMBER(20,4),
    P06FEO        NUMBER(20,4),
    P07MGO        NUMBER(20,4),
    P08S          NUMBER(20,4),
    P09R          NUMBER(20,4),
    CONSTRAINT "��ԭ�ϳɷ�����" PRIMARY KEY(P01����,P02����)
);