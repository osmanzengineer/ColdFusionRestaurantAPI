--
-- PostgreSQL database dump
--

-- Dumped from database version 16.2
-- Dumped by pg_dump version 16.2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Category; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Category" (
    "ID" uuid DEFAULT gen_random_uuid() NOT NULL,
    "Name" character varying(100) NOT NULL
);


ALTER TABLE public."Category" OWNER TO postgres;

--
-- Name: Customer; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Customer" (
    "ID" uuid DEFAULT gen_random_uuid() NOT NULL,
    "Description" character varying(100) NOT NULL
);


ALTER TABLE public."Customer" OWNER TO postgres;

--
-- Name: MenuItem; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."MenuItem" (
    "ID" uuid DEFAULT gen_random_uuid() NOT NULL,
    "CategoryID" uuid NOT NULL,
    "Name" character varying(100) NOT NULL,
    "Description" character varying(100) NOT NULL,
    "Price" double precision NOT NULL,
    "IsPermanent" boolean NOT NULL,
    "IsActive" boolean NOT NULL,
    "GlutenFree" boolean NOT NULL,
    "IsVegan" boolean NOT NULL,
    "CreateDate" timestamp with time zone NOT NULL,
    "DayOfWeek" integer
);


ALTER TABLE public."MenuItem" OWNER TO postgres;

--
-- Name: Order; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Order" (
    "ID" uuid DEFAULT gen_random_uuid() NOT NULL,
    "CustomerID" uuid NOT NULL,
    "MenuItemID" uuid NOT NULL,
    "Count" integer NOT NULL,
    "OrderDate" timestamp with time zone NOT NULL,
    "OrderNote" text,
    "IsChecked" boolean NOT NULL
);


ALTER TABLE public."Order" OWNER TO postgres;

--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- Data for Name: Category; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Category" ("ID", "Name") FROM stdin;
070e119a-fcb5-4a40-9ae7-be48e08f6d37    Foods
9020fda2-ade5-4140-9699-e14bc418ce44    Drinks
aab10325-9fa6-4eb1-ad87-65e8a7fb5699    Soup
e9298e20-67de-49e7-b5cf-6c1141422cef    Snacks
\.


--
-- Data for Name: Customer; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Customer" ("ID", "Description") FROM stdin;
2efda96f-7303-4160-9798-62745cdf3139    Balkon-1
c1637f94-7ab0-400f-852c-41f0ce3d0fa0    Balkon-2
34ed13e2-2a93-4b1b-9a50-0cab68637ebf    Salon-1
c2cc338d-91fb-470e-8e1c-2160c21b141d    Salon-2
d80a6462-4795-42ce-9e38-ced4a083c791    Salon-3
\.


--
-- Data for Name: MenuItem; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."MenuItem" ("ID", "CategoryID", "Name", "Description", "Price", "IsPermanent", "IsActive", "GlutenFree", "IsVegan", "CreateDate", "DayOfWeek") FROM stdin;
31f13d31-e2ae-4f75-b122-85cd772a8894    070e119a-fcb5-4a40-9ae7-be48e08f6d37    Patates Patates , su    14      f      tt       t       2024-04-19 22:18:38.250339+03   0
8e515c45-3443-4857-979b-e5eb2ac6ef91    e9298e20-67de-49e7-b5cf-6c1141422cef    Meze    nohut, su       1       t      tf       t       2024-04-19 23:09:32.723485+03   \N
\.


--
-- Data for Name: Order; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Order" ("ID", "CustomerID", "MenuItemID", "Count", "OrderDate", "OrderNote", "IsChecked") FROM stdin;
b9244d43-572c-4335-a37b-afa83fdabc5b    d80a6462-4795-42ce-9e38-ced4a083c791    31f13d31-e2ae-4f75-b122-85cd772a8894   22024-04-19 22:45:44.959972+03           t
\.


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20240419190823_restoranDB       8.0.4
20240419201324_19-04    8.0.4
20240419203126_19-04.1  8.0.4
20240419203254_19-04.2  8.0.4
\.


--
-- Name: Category PK_Category; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Category"
    ADD CONSTRAINT "PK_Category" PRIMARY KEY ("ID");


--
-- Name: Customer PK_Customer; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Customer"
    ADD CONSTRAINT "PK_Customer" PRIMARY KEY ("ID");


--
-- Name: MenuItem PK_MenuItem; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MenuItem"
    ADD CONSTRAINT "PK_MenuItem" PRIMARY KEY ("ID");


--
-- Name: Order PK_Order; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Order"
    ADD CONSTRAINT "PK_Order" PRIMARY KEY ("ID");


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: IX_MenuItem_CategoryID; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_MenuItem_CategoryID" ON public."MenuItem" USING btree ("CategoryID");


--
-- Name: IX_Order_CustomerID; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Order_CustomerID" ON public."Order" USING btree ("CustomerID");


--
-- Name: IX_Order_MenuItemID; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Order_MenuItemID" ON public."Order" USING btree ("MenuItemID");


--
-- Name: MenuItem FK_MenuItem_Category_CategoryID; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MenuItem"
    ADD CONSTRAINT "FK_MenuItem_Category_CategoryID" FOREIGN KEY ("CategoryID") REFERENCES public."Category"("ID") ON DELETE CASCADE;


--
-- Name: Order FK_Order_Customer_CustomerID; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Order"
    ADD CONSTRAINT "FK_Order_Customer_CustomerID" FOREIGN KEY ("CustomerID") REFERENCES public."Customer"("ID") ON DELETE CASCADE;


--
-- Name: Order FK_Order_MenuItem_MenuItemID; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Order"
    ADD CONSTRAINT "FK_Order_MenuItem_MenuItemID" FOREIGN KEY ("MenuItemID") REFERENCES public."MenuItem"("ID") ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--