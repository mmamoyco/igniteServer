﻿using System;
using System.Collections.Generic;
using System.Text;
using Ignite.src.core.networkentities;


namespace Ignite.src.core.engine.validator
{
    class IgniteRequestValidatorService
    {

        private static String validHttpVersion = "HTTP/1.1";

        // core request engine low level validation logic
        public static IgniteResponseStatus validate(IgniteRequest request) {

            // not valid version
           // if (!request.getHttpVersion().Equals(validHttpVersion)) {
             //   Console.WriteLine("IgniteERquestValidatorService@validate | http version not valid, sending 400");
               // return new IgniteResponseStatus(HttpStatus.BAD_REQUEST, HttpStatus.BAD_REQUEST_MESSAGE);
            //}

            if (request.getRoute().Equals("")) {
                Console.WriteLine("IgniteERquestValidatorService@validate | route not valid, sending 400");
                return new IgniteResponseStatus(HttpStatus.BAD_REQUEST, HttpStatus.BAD_REQUEST_MESSAGE);
            }

            if (!request.getMethod().Equals(HttpMethod.GET) && !request.getHeaders().ContainsKey(HttpHeaders.ContentLength)) {
                Console.WriteLine("IgniteERquestValidatorService@validate | no content length header sending 411");
                return new IgniteResponseStatus(HttpStatus.LENGTH_REQUIRED, HttpStatus.LENGTH_REQUIRED_MESSAGE);
            }

            if (HttpMethod.getAvalibleMethods().IndexOf(request.getMethod()) == -1) {
                Console.WriteLine("IgniteERquestValidatorService@validate | not allowed method, sending 405");
                return new IgniteResponseStatus(HttpStatus.METHOD_NOT_ALLOWED, HttpStatus.METHOD_NOT_ALLOWED_MESSAGE);
            }

            Dictionary<String, String> headers = request.getHeaders();
            foreach (KeyValuePair<String, String> entry in headers) {

                if (entry.Key.Equals("") || entry.Value.Equals("")) {
                    Console.WriteLine("IgniteERquestValidatorService@validate | headers not valid, sending 400");
                    return new IgniteResponseStatus(HttpStatus.BAD_REQUEST, HttpStatus.BAD_REQUEST_MESSAGE);
                }
            }


            return new IgniteResponseStatus(HttpStatus.OK, HttpStatus.OK_MESSAGE);
        }
    }
}