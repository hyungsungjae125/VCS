use VCS_DB;

/*ȸ������-------------------------------------------------------------------------------*/
insert into Division (dName) values ('�Ϲ�ȸ��');
insert into Division (dName) values ('������');
insert into Division (dName) values ('������');

select * from Division;
/*ȸ��-------------------------------------------------------------------------------*/
insert into Member (dNo,mId,mPw,mName,mAddr,mNumber) values(3,'root','1234','������','���굿 �븢3��','010-1234-5678');
insert into Member (dNo,mId,mPw,mName,mAddr,mNumber) values(1,'hsj','0000','������','��ź6�� �ݵ�8��','010-4192-9741');
insert into Member (dNo,mId,mPw,mName,mAddr,mNumber,aName) values(2,'goodee','1111','����','�븢3��','010-1111-2222','����');

select * from Member;
select m.mNo,d.dName as '����',m.mId as '���̵�',m.mPw as '���',m.mName,m.mAddr,mNumber from Member m inner join Division d on (m.dNo=d.dNo);
/*������-------------------------------------------------------------------------------*/

/*��û����-------------------------------------------------------------------------------*/

/*����-------------------------------------------------------------------------------*/
insert into Notice(mNo,nTitle,nContents,nUrl) values(1,'�����׽�Ʈ','����','�׽�Ʈurl');
insert into Notice(mNo,nTitle,nContents,nUrl) values(1,'�����׽�Ʈ1','����1','�׽�Ʈurl1');
/*�亯-------------------------------------------------------------------------------*/

/*����-------------------------------------------------------------------------------*/
insert into Question (mNo,qTitle,qContents,qUrl)values(2,'��������','��������','url1');
insert into Question (mNo,qTitle,qContents,qUrl)values(2,'��������2','��������2','url2');
/*�ܺκ���-------------------------------------------------------------------------------*/
insert into Outside(mNo,oUrl) values(2,'testurl');
insert into Outside(mNo,oUrl) values(2,'testurl1');
insert into Outside(mNo,oUrl) values(2,'testurl2');
/*-------------------------------------------------------------------------------*/

