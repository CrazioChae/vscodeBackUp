함수
 - AVG
 - MAX
 - MIN
 - SUM
 - COUNT

그룹
 - SELECT 목록 열 중 그룹 함수에 없는 열은 모두
 GROUP BY 절에 포함되어야 함

* HAVING
 - 그룹이 생성 된 이후 그룹 절에서 사용하는 조건 절


SELECT AVG(SALARY), MAX(SALARY), MIN(SALARY), SUM(SALARY)
FROM EMPLOYEES
WHERE JOB_ID LIKE '%REP%';

SELECT COUNT(COMMISSION_PCT)
FROM EMPLOYEES
WHERE DEPARTMENT_ID = 80;

SELECT AVG(COMMISSION_PCT)
FROM EMPLOYEES;

SELECT DEPARTMENT_ID, SUM(SALARY)
FROM EMPLOYEES;

SELECT DEPARTMENT_ID, AVG(SALARY)
FROM EMPLOYEES
GROUP BY DEPARTMENT_ID
ORDER BY DEPARTMENT_ID ASC;

SELECT DEPARTMENT_ID DEPT_ID, JOB_ID, SUM(SALARY)
FROM EMPLOYEES
GROUP BY DEPARTMENT_ID, JOB_ID
ORDER BY DEPARTMENT_ID;

SELECT DEPARTMENT_ID, COUNT(JOB_ID)
FROM EMPLOYEES
GROUP BY DEPARTMENT_ID;

SELECT DEPARTMENT_ID DEPTID, JOB_ID, SUM(SALARY)
FROM EMPLOYEES
GROUP BY DEPARTMENT_ID, JOB_ID
ORDER BY SUM(SALARY);

SELECT DEPARTMENT_ID, AVG(SALARY)
FROM EMPLOYEES
HAVING AVG(SALARY) > 8000
GROUP BY DEPARTMENT_ID;/

SELECT DEPARTMENT_ID, MAX(SALARY)
FROM EMPLOYEES
GROUP BY DEPARTMENT_ID
HAVING MAX(SALARY) > 10000
ORDER BY DEPARTMENT_ID;

SELECT JOB_ID, SUM(SALARY) PAYROLL
FROM EMPLOYEES
WHERE JOB_ID NOT LIKE '%REP%'
GROUP BY JOB_ID
HAVING SUM(SALARY) > 13000
ORDER BY SUM(SALARY);
 > 해석 : 업무가 REP가 아닌 사람들 중 월급이 13000을 초과하는
 사원들의 JOB_ID, SUM(SALARY) AS PAYROLL을 구하고
 월급의 합으로 정렬하라

SELECT JOB_ID, MAX(SALARY) AS MAX, MIN(SALARY) AS MIN,
 SUM(SALARY) AS SUM, AVG(SALARY) AS AVG
FROM EMPLOYEES
GROUP BY JOB_ID
ORDER BY JOB_ID ASC;

SELECT DEPARTMENT_ID, AVG(SALARY)
FROM EMPLOYEES
WHERE DEPARTMENT_ID != 100
GROUP BY DEPARTMENT_ID
HAVING AVG(SALARY) >= 7000
ORDER BY DEPARTMENT_ID;

SELECT MANAGER_ID , AVG(SALARY) AS AVG
FROM EMPLOYEES
WHERE DEPARTMENT_ID = 50
GROUP BY MANAGER_ID;

SELECT JOB_ID, COUNT(EMPLOYEE_ID)
FROM EMPLOYEES
GROUP BY JOB_ID
ORDER BY JOB_ID;

SELECT DEPARTMENT_ID, COUNT(EMPLOYEE_ID)
FROM EMPLOYEES
GROUP BY DEPARTMENT_ID
HAVING COUNT(EMPLOYEE_ID) >= 4
ORDER BY DEPARTMENT_ID;

SELECT COUNT(DISTINCT MANAGER_ID)
FROM EMPLOYEES;